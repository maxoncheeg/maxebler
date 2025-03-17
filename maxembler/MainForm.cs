using System.Security.Policy;
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

        runCode.Click += (_, _) =>
            textBoxError.Text =
                $"ERROR: ОШИБКА СИНТАКСИСА В СТРОКЕ. НЕТ ТАКОЙ ФУНКЦИИ (symbol №{textBoxCode.Text.Length + 1})";
        textBoxError.ReadOnly = true;

        KeyPreview = true;

        this.KeyDown += OnTextBoxCodeKeyDown;


        testButton.Visible = false;
        //testButton.Click += (_, _) =>
        //{
        //    var searchText = "https";
        //    var text = textBoxCode.Text;
        //    var index = text.IndexOf(searchText);

        //    textBoxCode.SelectionStart = index;
        //    textBoxCode.SelectionLength = searchText.Length;

        //    textBoxCode.SelectionColor = Color.Orange;

        //    textBoxCode.SelectionLength = 0;
        //};
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