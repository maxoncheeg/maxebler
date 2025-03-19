using System.Security.Policy;
using System.Text.RegularExpressions;
using maxembler.Models;

namespace maxembler;

public partial class MainForm : Form
{
    private string _fileName = string.Empty;
    private bool _textCommand = false;
    private int _currentIndex = 0;

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
                @"(http(s)?:\/\/.)?(www\.)?[-a-z0-9@:%._\+~#=]{2,256}\.[a-z]{2,63}([-a-zA-Z0-9@:%_\+.~#?&/=]*)", RegexOptions.IgnoreCase);
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
            @"(http(s)?:\/\/.)?(www\.)?[-a-z0-9@:%._\+~#=]{2,256}\.[a-z]{2,63}([-a-zA-Z0-9@:%_\+.~#?&/=]*)", RegexOptions.IgnoreCase);
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
}