using System;
using System.Collections.Generic;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class TextEditor
{
    public string Text { get; private set; } = "";

    public void Write(string newText)
    {
        Text += newText;
    }

    public void Delete(int length)
    {
        if (length <= Text.Length)
        {
            Text = Text.Substring(0, Text.Length - length);
        }
    }

    public void Show()
    {
        Console.WriteLine(Text);
    }
}

public class WriteTextCommand : ICommand
{
    private TextEditor editor;
    private string text;

    public WriteTextCommand(TextEditor editor, string text)
    {
        this.editor = editor;
        this.text = text;
    }

    public void Execute()
    {
        editor.Write(text);
    }

    public void Undo()
    {
        editor.Delete(text.Length);
    }
}

public class DeleteTextCommand : ICommand
{
    private TextEditor editor;
    private string deletedText;

    public DeleteTextCommand(TextEditor editor, int length)
    {
        this.editor = editor;
        deletedText = editor.Text.Substring(editor.Text.Length - length);
    }

    public void Execute()
    {
        editor.Delete(deletedText.Length);
    }

    public void Undo()
    {
        editor.Write(deletedText);
    }
}

public class CommandManager
{
    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
        redoStack.Clear();
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            var command = undoStack.Pop();
            command.Undo();
            redoStack.Push(command);
        }
    }

    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            var command = redoStack.Pop();
            command.Execute();
            undoStack.Push(command);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var editor = new TextEditor();
        var commandManager = new CommandManager();

        commandManager.ExecuteCommand(new WriteTextCommand(editor, "Hello, "));
        commandManager.ExecuteCommand(new WriteTextCommand(editor, "world!"));

        commandManager.Undo();
        commandManager.Undo(); 

        commandManager.Redo();
        editor.Show();
    }
}