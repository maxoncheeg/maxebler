using System.Text.RegularExpressions;

namespace maxembler.Views
{
    public partial class MainForm
    {
        private void OpenFile(object? sender, EventArgs args)
        {
            SafeSave();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MAXEMBLER FILE|*.mxblr";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _fileName = dialog.FileName;
                textBoxCode.Text = File.ReadAllText(_fileName);
                _currentIndex = textBoxCode.Text.Length - 1;
                textBoxCode.SelectionStart = _currentIndex;
                _changesKeeper.ClearChanges();
            }

            textBoxCode.Focus();
        }

        private async void SaveFile(object? sender, EventArgs args)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "MAXEMBLER FILE|*.mxblr";

            if (!string.IsNullOrEmpty(_fileName))
            {
                dialog.FileName = _fileName;
                await File.WriteAllTextAsync(dialog.FileName, textBoxCode.Text);
            }
            else if (dialog.ShowDialog() == DialogResult.OK)
            {
                await File.WriteAllTextAsync(dialog.FileName, textBoxCode.Text);
                _fileName = dialog.FileName;
            }

            _changesKeeper.ClearChanges();

            textBoxCode.Focus();
        }

        private async void SaveAsFile(object? sender, EventArgs args)
        {
            SaveFileDialog dialog = new SaveFileDialog();


            dialog.Filter = "MAXEMBLER FILE|*.mxblr";

            if (!string.IsNullOrEmpty(_fileName))
            {
                dialog.FileName = _fileName;
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                await File.WriteAllTextAsync(dialog.FileName, textBoxCode.Text);
                _fileName = dialog.FileName;
            }

            _changesKeeper.ClearChanges();

            textBoxCode.Focus();
        }

        private void NewFile(object? sender, EventArgs args)
        {
            SafeSave();
            _changesKeeper.ClearChanges();
            _currentIndex = 0;
            textBoxCode.Text = _fileName = string.Empty;
            _changesKeeper.AddChanges(textBoxCode.Text);

            textBoxCode.Focus();
        }

        private void BackChanges(object? sender, EventArgs args)
        {
            _textCommand = true;
            textBoxCode.Text = _changesKeeper.GoBack();

            textBoxCode.Focus();
        }

        private void ForwardChanges(object? sender, EventArgs args)
        {
            _textCommand = true;
            textBoxCode.Text = _changesKeeper.GoForward();

            textBoxCode.Focus();
        }

        private void CopyText(object? sender, EventArgs args)
        {
            var copiedText = textBoxCode.SelectedText;
            if (!string.IsNullOrEmpty(copiedText))
            {
                Clipboard.SetText(copiedText);
            }

            textBoxCode.Focus();
        }

        private void CutText(object? sender, EventArgs args)
        {
            var copiedText = textBoxCode.SelectedText;
            textBoxCode.Text = textBoxCode.Text[..textBoxCode.SelectionStart] +
                               textBoxCode.Text[(textBoxCode.SelectionStart + textBoxCode.SelectionLength)..];
            if (!string.IsNullOrEmpty(copiedText))
                Clipboard.SetText(copiedText);

            textBoxCode.Focus();
        }

        private void PasteText(object? sender, EventArgs args)
        {
            var text = Clipboard.GetText();

            if (string.IsNullOrEmpty(text)) return;
            var index = textBoxCode.SelectionStart;
            textBoxCode.Text = textBoxCode.Text.Insert(textBoxCode.SelectionStart, text ?? "");
            textBoxCode.SelectionStart = index + text.Length;

            textBoxCode.Focus();
        }

        private void SelectAll(object? sender, EventArgs args)
        {
            textBoxCode.SelectAll();

            textBoxCode.Focus();
        }

        private void DeleteText(object? sender, EventArgs args)
        {
            textBoxCode.Text = textBoxCode.Text.Remove(textBoxCode.SelectionStart, textBoxCode.SelectionLength);

            textBoxCode.Focus();
        }

        private void RunCode(object? sender, EventArgs args)
        {
            var matches = Regex.Matches(textBoxCode.Text,
                _pattern, RegexOptions.IgnoreCase);

            var newLineIndexes = textBoxCode.Text.Index().Where(tuple => tuple.Item is '\n' or '\v')
                .Select(tuple => tuple.Index).ToList();
            newLineIndexes.Add(textBoxCode.Text.Length);

            string result = "";
            result += $"\tВсего найдено ссылок: {matches.Count}{Environment.NewLine}";
            if (matches.Count > 0) result += $"Результаты:{Environment.NewLine}";

            int position = 0, line = 0;
            foreach (Match match in matches)
            {
                for (int i = 0; i < newLineIndexes.Count; i++)
                {
                    if (match.Index >= newLineIndexes[i]) continue;
                    position = i > 0 ? match.Index - newLineIndexes[i - 1] : match.Index + 1;
                    line = i + 1;
                    break;
                }

                result += $"({line}:{position}): {match.Value}{Environment.NewLine}";
            }

            textBoxError.Text = result;
        }

        private void RunFiniteStateCode(object? sender, EventArgs args)
        {
            _urlStateMachine.Reset();

            var text = textBoxCode.Text + " ";
            textBoxError.Text = string.Empty;

            _urlStateMachine.ErrorOccurred += (o, eventArgs) =>
            {
                foreach (var error in eventArgs.Errors)
                {
                    if (error.Text != "")
                        textBoxError.Text += $"pos:{error.Position}| {error.Text}{Environment.NewLine}";
                }
            };

            _urlStateMachine.StateChanged += (o, e) =>
            {
                if (e.HasSearchCompleted)
                {
                    textBoxError.Text +=
                        $"НАЙДЕНО:{text.Substring(e.StartIndex.Value, e.Length.Value)}{Environment.NewLine}{Environment.NewLine}";
                    Console.WriteLine($"{e.PreviousState} -> {e.Route} -> {e.CurrentState} | {text.Substring(e.StartIndex.Value, e.Length.Value)}");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    textBoxError.Text += $"{e.PreviousState} -> {e.CurrentState} |";
                    Console.WriteLine($"{e.PreviousState} -> {(e.Route.Contains("\n") ? "newline or space" : e.Route)} -> {e.CurrentState} | {text.Substring(e.StartIndex.Value, e.Length.Value)}");
                }
            };


            for (int i = 0; i < text.Length; i++)
            {
                _urlStateMachine.PutChar(text[i], i);
            }
        }
    }
}