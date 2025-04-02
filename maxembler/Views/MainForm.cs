using System.Text.RegularExpressions;
using maxembler.Models;
using maxembler.Models.StateMachines;
using maxembler.Models.StateMachines.Abstract;
using maxembler.Models.StateMachines.Routes;

namespace maxembler.Views;

public partial class MainForm : Form
{
    private string _fileName = string.Empty;
    private bool _textCommand = false;
    private int _currentIndex = 0;

    private readonly string _pattern =
        @"(http(s)?:\/\/.)?(www\.)?([a-z0-9]+[-a-z0-9]*[a-z0-9]+\.)+[a-z]{2,63}([-a-zA-Z0-9@:%_\+.~#?&\/=]*)";

    private IChangesKeeper _changesKeeper = new MemoryChangesKeeper();

    private bool SaveNeeded => _changesKeeper.HasChanges &&
                               !(string.IsNullOrEmpty(_fileName) && string.IsNullOrEmpty(textBoxCode.Text));

    public MainForm()
    {
        InitializeComponent();

        buttonOpen.Click += OpenFile;
        fileOpen.Click += OpenFile;

        buttonSave.Click += SaveFile;
        fileSave.Click += SaveFile;
        fileSaveAs.Click += SaveAsFile;

        buttonNew.Click += NewFile;
        fileCreate.Click += NewFile;

        textBoxCode.TextChanged += TextBoxCodeChanged;

        buttonBack.Click += BackChanges;
        editBack.Click += BackChanges;

        buttonForward.Click += ForwardChanges;
        editForward.Click += ForwardChanges;

        buttonCopy.Click += CopyText;
        editCopy.Click += CopyText;

        buttonCut.Click += CutText;
        editCut.Click += CutText;

        buttonPaste.Click += PasteText;
        editPaste.Click += PasteText;

        editDelete.Click += DeleteText;
        editSelect.Click += SelectAll;

        fileExit.Click += (_, _) => this.Close();
        FormClosed += MainForm_FormClosed;

        help.Click += (_, _) =>
        {
            var helpForm = new HelpForm();
            helpForm.ShowDialog();
        };

        runCode.Click += RunCode;
        buttonRunCode.Click += RunCode;
        textBoxError.ReadOnly = true;

        KeyPreview = true;

        this.KeyDown += OnTextBoxCodeKeyDown;

        _changesKeeper.ChangesOccurred += (_, args) =>
        {
            buttonBack.Enabled = editBack.Enabled = args.CanBackChanges;
            buttonForward.Enabled = buttonForward.Enabled = args.CanForwardChanges;
        };

        textBoxCode.Focus();

        testButton.Visible = true;
        textBoxCode.DetectUrls = false;
        testButton.Click += (_, _) =>
        {

            var text = textBoxCode.Text;

            var result = Regex.Matches(text,
                @"(http(s)?:\/\/.)?(www\.)?[-a-z0-9@:%._\+~#=]{2,256}\.[a-z]{2,63}([-a-zA-Z0-9@:%_\+.~#?&/=]*)",
                RegexOptions.IgnoreCase);
            textBoxCode.SelectionColor = Color.Orange;
            foreach (Match match in result)
            {
                textBoxCode.SelectionStart = match.Index;
                textBoxCode.SelectionLength = match.Length;
                textBoxCode.SelectionColor = Color.Orange;
                textBoxCode.SelectionLength = 0;
            }

            textBoxCode.SelectionColor = Color.Black;
            textBoxCode.ForeColor = Color.Black;
        };
    }

    private void OnTextBoxCodeKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Control) e.Handled = true;

        if (e.Control && e.KeyCode == Keys.Z) BackChanges(sender, e);
        else if (e.Control && e.KeyCode == Keys.X) CutText(sender, e);
        else if (e.Control && e.Shift && e.KeyCode == Keys.Z) ForwardChanges(sender, e);
        else if (e.Control && e.KeyCode == Keys.Y) ForwardChanges(sender, e);
        else if (e.KeyData == (Keys.C | Keys.Control)) CopyText(sender, e);
        else if (e.KeyData == (Keys.V | Keys.Control)) PasteText(sender, e);
        else if (e.Control && e.KeyCode == Keys.A) SelectAll(sender, e);
        else if (e.Control && e.KeyCode == Keys.S) SaveFile(sender, e);
        else if (e.Control && e.KeyCode == Keys.O) OpenFile(sender, e);
    }

    private void MainForm_FormClosed(object? sender, FormClosedEventArgs e)
    {
        SafeSave();
    }

    private void TextBoxCodeChanged(object? sender, EventArgs e)
    {
        if (_textCommand)
        {
            _textCommand = false;
            return;
        }

        _changesKeeper.AddChanges(textBoxCode.Text);
        _currentIndex = textBoxCode.SelectionStart;
        
        
        var result = Regex.Matches(textBoxCode.Text,
            _pattern, RegexOptions.IgnoreCase);
        textBoxCode.SelectionColor = Color.Orange;
        foreach (Match match in result)
        {
            textBoxCode.SelectionStart = match.Index;
            textBoxCode.SelectionLength = match.Length;
            textBoxCode.SelectionColor = Color.Orange;
            textBoxCode.SelectionLength = 0;
        }
        
        textBoxCode.SelectionStart = _currentIndex;
        textBoxCode.SelectionColor = Color.Black;
        textBoxCode.ForeColor = Color.Black;
    }

    private void FormLoad(object sender, EventArgs e)
    {
        NewFile(null, EventArgs.Empty);
        Test();
    }

    private void SafeSave()
    {
        if (!SaveNeeded) return;
        var result = MessageBox.Show("Вы хотите сохранить изменения?", "ВНИМАНИЕ!", MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);


        if (result == DialogResult.OK)
        {
            SaveFile(null, EventArgs.Empty);
        }
    }


    private void Test()
    {
        
        string text =
            "for(int i=2323;i<-12312;i++) for(int i=-1;i<+5;i++) ffor(int i=0;i>22222222222222222;i++) for(int i=0;i>222222hui22222222222;i++)";

// List<IRoute> states = [
//     //new StringRoute("aboba", "A", "B"),
//     //ew StringRoute("abobes", "A", "B"),
//     
//     new RegexSymbolRoute(@"[a-z]", "A", "A"),
//     new StringRoute(".", "A", "C"),
//     new RegexSymbolRoute(@"[a-z]", "C", "C"),
//     new StringRoute("/", "C", "D"),
// ];

        List<IRoute> states =
        [
            new StringRoute("for", "F", "E"),
            new StringRoute("(", "E", "T"),
            new StringRoute("int ", "T", "V"),
            new StringRoute("i", "V", "A"),
            new StringRoute("=", "A", "P"),
            new RegexSymbolRoute(@"[\+\-\d]", "P", "D"),
            new RegexSymbolRoute(@"\d", "D", "D"),
            new StringRoute(";", "D", "C"),
            new StringRoute("i", "C", "Q"),

            new StringRoute("<", "Q", "R"),
            new StringRoute(">", "Q", "R"), //  и тд.

            new RegexSymbolRoute(@"[\+\-\d]", "R", "B"),
            new RegexSymbolRoute(@"\d", "B", "B", "Ожидается число!"),
            new StringRoute(";", "B", "I"),
            new StringRoute("i++", "I", "Z"),
            new StringRoute(")", "Z", "END"),
        ];

        textBoxCode.Text = text;
        IFiniteStateMachine stateMachine = new FiniteStateMachine(states, "F", "END");
        stateMachine.StateChanged += (s, e) =>
        {
            if (e.HasSearchCompleted)
            {
                textBoxError.Text += $"НАЙДЕНО: {text.Substring(e.StartIndex.Value, e.Length.Value)} {Environment.NewLine}";
            }
        };

        stateMachine.ErrorOccurred += (s, e) =>
        {
            foreach (var error in e.Errors)
            {
                if (!string.IsNullOrEmpty(error.Error))
                {
                    textBoxCode.ForeColor = Color.Red;
                    textBoxError.Text += $"{text.Substring(error.StartIndex, error.Length)}  ->>>  {error.Error}{Environment.NewLine}";
                    textBoxCode.ForeColor = Color.Black;;
                }
            }
        };

        for (int i = 0; i < text.Length; i++)
        {
            stateMachine.PutChar(text[i], i);
        }
    }
}