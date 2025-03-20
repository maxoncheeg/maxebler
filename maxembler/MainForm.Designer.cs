namespace maxembler;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        menu = new System.Windows.Forms.MenuStrip();
        файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        fileCreate = new System.Windows.Forms.ToolStripMenuItem();
        fileOpen = new System.Windows.Forms.ToolStripMenuItem();
        fileSave = new System.Windows.Forms.ToolStripMenuItem();
        fileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
        fileExit = new System.Windows.Forms.ToolStripMenuItem();
        правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        editBack = new System.Windows.Forms.ToolStripMenuItem();
        editForward = new System.Windows.Forms.ToolStripMenuItem();
        editCut = new System.Windows.Forms.ToolStripMenuItem();
        editCopy = new System.Windows.Forms.ToolStripMenuItem();
        editPaste = new System.Windows.Forms.ToolStripMenuItem();
        editDelete = new System.Windows.Forms.ToolStripMenuItem();
        editSelect = new System.Windows.Forms.ToolStripMenuItem();
        текстToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        постановкаЗадачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        иТакДалееToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        runCode = new System.Windows.Forms.ToolStripMenuItem();
        справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        help = new System.Windows.Forms.ToolStripMenuItem();
        оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        textBoxError = new System.Windows.Forms.TextBox();
        buttonNew = new System.Windows.Forms.Button();
        buttonOpen = new System.Windows.Forms.Button();
        buttonSave = new System.Windows.Forms.Button();
        buttonBack = new System.Windows.Forms.Button();
        buttonForward = new System.Windows.Forms.Button();
        buttonCopy = new System.Windows.Forms.Button();
        buttonCut = new System.Windows.Forms.Button();
        buttonPaste = new System.Windows.Forms.Button();
        textBoxCode = new System.Windows.Forms.RichTextBox();
        testButton = new System.Windows.Forms.Button();
        helpProvider = new System.Windows.Forms.HelpProvider();
        buttonRunCode = new System.Windows.Forms.Button();
        menu.SuspendLayout();
        SuspendLayout();
        // 
        // menu
        // 
        menu.ImageScalingSize = new System.Drawing.Size(18, 18);
        menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { файлToolStripMenuItem, правкаToolStripMenuItem, текстToolStripMenuItem, runCode, справкаToolStripMenuItem });
        menu.Location = new System.Drawing.Point(0, 0);
        menu.Name = "menu";
        menu.Size = new System.Drawing.Size(926, 27);
        menu.TabIndex = 1;
        menu.Text = "menuStrip1";
        // 
        // файлToolStripMenuItem
        // 
        файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { fileCreate, fileOpen, fileSave, fileSaveAs, fileExit });
        файлToolStripMenuItem.Name = "файлToolStripMenuItem";
        файлToolStripMenuItem.Size = new System.Drawing.Size(55, 23);
        файлToolStripMenuItem.Text = "Файл";
        // 
        // fileCreate
        // 
        fileCreate.Name = "fileCreate";
        fileCreate.Size = new System.Drawing.Size(221, 24);
        fileCreate.Text = "Создать";
        // 
        // fileOpen
        // 
        fileOpen.Name = "fileOpen";
        fileOpen.ShortcutKeyDisplayString = "Ctrl+WWW";
        fileOpen.Size = new System.Drawing.Size(221, 24);
        fileOpen.Text = "Открыть";
        // 
        // fileSave
        // 
        fileSave.Name = "fileSave";
        fileSave.Size = new System.Drawing.Size(221, 24);
        fileSave.Text = "Сохранить";
        // 
        // fileSaveAs
        // 
        fileSaveAs.Name = "fileSaveAs";
        fileSaveAs.Size = new System.Drawing.Size(221, 24);
        fileSaveAs.Text = "Сохранить как...";
        // 
        // fileExit
        // 
        fileExit.Name = "fileExit";
        fileExit.Size = new System.Drawing.Size(221, 24);
        fileExit.Text = "Выход";
        // 
        // правкаToolStripMenuItem
        // 
        правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { editBack, editForward, editCut, editCopy, editPaste, editDelete, editSelect });
        правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
        правкаToolStripMenuItem.Size = new System.Drawing.Size(69, 23);
        правкаToolStripMenuItem.Text = "Правка";
        // 
        // editBack
        // 
        editBack.Name = "editBack";
        editBack.Size = new System.Drawing.Size(171, 24);
        editBack.Text = "Отменить";
        // 
        // editForward
        // 
        editForward.Name = "editForward";
        editForward.Size = new System.Drawing.Size(171, 24);
        editForward.Text = "Повторить";
        // 
        // editCut
        // 
        editCut.Name = "editCut";
        editCut.Size = new System.Drawing.Size(171, 24);
        editCut.Text = "Вырезать";
        // 
        // editCopy
        // 
        editCopy.Name = "editCopy";
        editCopy.Size = new System.Drawing.Size(171, 24);
        editCopy.Text = "Копировать";
        // 
        // editPaste
        // 
        editPaste.Name = "editPaste";
        editPaste.Size = new System.Drawing.Size(171, 24);
        editPaste.Text = "Вставить";
        // 
        // editDelete
        // 
        editDelete.Name = "editDelete";
        editDelete.Size = new System.Drawing.Size(171, 24);
        editDelete.Text = "Удалить";
        // 
        // editSelect
        // 
        editSelect.Name = "editSelect";
        editSelect.Size = new System.Drawing.Size(171, 24);
        editSelect.Text = "Выделить всё";
        // 
        // текстToolStripMenuItem
        // 
        текстToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { постановкаЗадачиToolStripMenuItem, иТакДалееToolStripMenuItem });
        текстToolStripMenuItem.Name = "текстToolStripMenuItem";
        текстToolStripMenuItem.Size = new System.Drawing.Size(56, 23);
        текстToolStripMenuItem.Text = "Текст";
        // 
        // постановкаЗадачиToolStripMenuItem
        // 
        постановкаЗадачиToolStripMenuItem.Name = "постановкаЗадачиToolStripMenuItem";
        постановкаЗадачиToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
        постановкаЗадачиToolStripMenuItem.Text = "Постановка задачи";
        // 
        // иТакДалееToolStripMenuItem
        // 
        иТакДалееToolStripMenuItem.Name = "иТакДалееToolStripMenuItem";
        иТакДалееToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
        иТакДалееToolStripMenuItem.Text = "и так далее";
        // 
        // runCode
        // 
        runCode.BackColor = System.Drawing.Color.FromArgb(((int)((byte)205)), ((int)((byte)212)), ((int)((byte)240)));
        runCode.Image = ((System.Drawing.Image)resources.GetObject("runCode.Image"));
        runCode.Name = "runCode";
        runCode.Size = new System.Drawing.Size(71, 23);
        runCode.Text = "Пуск";
        // 
        // справкаToolStripMenuItem
        // 
        справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { help, оПрограммеToolStripMenuItem });
        справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
        справкаToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
        справкаToolStripMenuItem.Text = "Справка";
        // 
        // help
        // 
        help.Name = "help";
        help.Size = new System.Drawing.Size(180, 24);
        help.Text = "Вызов справки";
        // 
        // оПрограммеToolStripMenuItem
        // 
        оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
        оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
        оПрограммеToolStripMenuItem.Text = "О программе";
        // 
        // textBoxError
        // 
        textBoxError.BorderStyle = System.Windows.Forms.BorderStyle.None;
        textBoxError.Location = new System.Drawing.Point(29, 371);
        textBoxError.Multiline = true;
        textBoxError.Name = "textBoxError";
        textBoxError.Size = new System.Drawing.Size(885, 215);
        textBoxError.TabIndex = 3;
        // 
        // buttonNew
        // 
        buttonNew.BackgroundImage = global::maxembler.Properties.Resources.Снимок_экрана_2025_03_06_132101;
        buttonNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        buttonNew.Location = new System.Drawing.Point(12, 30);
        buttonNew.Name = "buttonNew";
        buttonNew.Size = new System.Drawing.Size(57, 50);
        buttonNew.TabIndex = 4;
        buttonNew.UseVisualStyleBackColor = true;
        // 
        // buttonOpen
        // 
        buttonOpen.BackgroundImage = global::maxembler.Properties.Resources.open;
        buttonOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        buttonOpen.Location = new System.Drawing.Point(75, 30);
        buttonOpen.Name = "buttonOpen";
        buttonOpen.Size = new System.Drawing.Size(57, 50);
        buttonOpen.TabIndex = 5;
        buttonOpen.UseVisualStyleBackColor = true;
        // 
        // buttonSave
        // 
        buttonSave.BackgroundImage = global::maxembler.Properties.Resources.save;
        buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        buttonSave.Location = new System.Drawing.Point(138, 30);
        buttonSave.Name = "buttonSave";
        buttonSave.Size = new System.Drawing.Size(57, 50);
        buttonSave.TabIndex = 6;
        buttonSave.UseVisualStyleBackColor = true;
        // 
        // buttonBack
        // 
        buttonBack.BackgroundImage = global::maxembler.Properties.Resources.back;
        buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        buttonBack.Location = new System.Drawing.Point(376, 30);
        buttonBack.Name = "buttonBack";
        buttonBack.Size = new System.Drawing.Size(57, 50);
        buttonBack.TabIndex = 7;
        buttonBack.UseVisualStyleBackColor = true;
        // 
        // buttonForward
        // 
        buttonForward.BackgroundImage = global::maxembler.Properties.Resources.fw;
        buttonForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        buttonForward.Location = new System.Drawing.Point(439, 30);
        buttonForward.Name = "buttonForward";
        buttonForward.Size = new System.Drawing.Size(57, 50);
        buttonForward.TabIndex = 8;
        buttonForward.UseVisualStyleBackColor = true;
        // 
        // buttonCopy
        // 
        buttonCopy.BackgroundImage = global::maxembler.Properties.Resources.cpy;
        buttonCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        buttonCopy.Location = new System.Drawing.Point(502, 30);
        buttonCopy.Name = "buttonCopy";
        buttonCopy.Size = new System.Drawing.Size(57, 50);
        buttonCopy.TabIndex = 9;
        buttonCopy.UseVisualStyleBackColor = true;
        // 
        // buttonCut
        // 
        buttonCut.BackgroundImage = global::maxembler.Properties.Resources.sty;
        buttonCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        buttonCut.Location = new System.Drawing.Point(565, 30);
        buttonCut.Name = "buttonCut";
        buttonCut.Size = new System.Drawing.Size(57, 50);
        buttonCut.TabIndex = 10;
        buttonCut.UseVisualStyleBackColor = true;
        // 
        // buttonPaste
        // 
        buttonPaste.BackgroundImage = global::maxembler.Properties.Resources.pst;
        buttonPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        buttonPaste.Location = new System.Drawing.Point(628, 30);
        buttonPaste.Name = "buttonPaste";
        buttonPaste.Size = new System.Drawing.Size(57, 50);
        buttonPaste.TabIndex = 11;
        buttonPaste.UseVisualStyleBackColor = true;
        // 
        // textBoxCode
        // 
        textBoxCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
        textBoxCode.Location = new System.Drawing.Point(29, 86);
        textBoxCode.Name = "textBoxCode";
        textBoxCode.Size = new System.Drawing.Size(897, 279);
        textBoxCode.TabIndex = 12;
        textBoxCode.Text = "";
        // 
        // testButton
        // 
        testButton.Location = new System.Drawing.Point(904, 30);
        testButton.Name = "testButton";
        testButton.Size = new System.Drawing.Size(10, 50);
        testButton.TabIndex = 13;
        testButton.Text = "SO COOL TEST BUTT";
        testButton.UseVisualStyleBackColor = true;
        // 
        // buttonRunCode
        // 
        buttonRunCode.BackgroundImage = global::maxembler.Properties.Resources.Снимок_экрана_2025_03_20_130318;
        buttonRunCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        buttonRunCode.Location = new System.Drawing.Point(313, 30);
        buttonRunCode.Name = "buttonRunCode";
        buttonRunCode.Size = new System.Drawing.Size(57, 50);
        buttonRunCode.TabIndex = 14;
        buttonRunCode.UseVisualStyleBackColor = true;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(926, 598);
        Controls.Add(buttonRunCode);
        Controls.Add(testButton);
        Controls.Add(textBoxCode);
        Controls.Add(buttonPaste);
        Controls.Add(buttonCut);
        Controls.Add(buttonCopy);
        Controls.Add(buttonForward);
        Controls.Add(buttonBack);
        Controls.Add(buttonSave);
        Controls.Add(buttonOpen);
        Controls.Add(buttonNew);
        Controls.Add(textBoxError);
        Controls.Add(menu);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        MainMenuStrip = menu;
        Text = "MAXEMBLER";
        Load += FormLoad;
        menu.ResumeLayout(false);
        menu.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button buttonRunCode;

    private System.Windows.Forms.MenuStrip menu;

    #endregion

    private ToolStripMenuItem файлToolStripMenuItem;
    private ToolStripMenuItem fileCreate;
    private ToolStripMenuItem fileOpen;
    private ToolStripMenuItem fileSave;
    private ToolStripMenuItem fileSaveAs;
    private ToolStripMenuItem fileExit;
    private ToolStripMenuItem правкаToolStripMenuItem;
    private ToolStripMenuItem editBack;
    private ToolStripMenuItem editForward;
    private ToolStripMenuItem editCut;
    private ToolStripMenuItem editCopy;
    private ToolStripMenuItem editPaste;
    private ToolStripMenuItem editDelete;
    private ToolStripMenuItem editSelect;
    private ToolStripMenuItem текстToolStripMenuItem;
    private ToolStripMenuItem постановкаЗадачиToolStripMenuItem;
    private ToolStripMenuItem иТакДалееToolStripMenuItem;
    private ToolStripMenuItem runCode;
    private ToolStripMenuItem справкаToolStripMenuItem;
    private ToolStripMenuItem help;
    private ToolStripMenuItem оПрограммеToolStripMenuItem;
    private TextBox textBoxError;
    private System.Windows.Forms.Button buttonNew;
    private Button buttonOpen;
    private Button buttonSave;
    private System.Windows.Forms.Button buttonBack;
    private System.Windows.Forms.Button buttonForward;
    private System.Windows.Forms.Button buttonCopy;
    private System.Windows.Forms.Button buttonCut;
    private System.Windows.Forms.Button buttonPaste;
    private System.Windows.Forms.RichTextBox textBoxCode;
    private System.Windows.Forms.Button testButton;
    private HelpProvider helpProvider;
}