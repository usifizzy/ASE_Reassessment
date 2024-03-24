using ASE.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE
{
    public partial class MultiLineForm : Form
    {
        private DrawingCanvas canvas;

        public MultiLineForm(DrawingCanvas canvas)
        {
            InitializeComponent();
            this.canvas = canvas;
        }


        private async void RunScriptBtn_Click(object sender, EventArgs e)
        {
            string scriptContent = multiCommandTextBox.Text;
            await Task.Run(() => ExecuteScript(scriptContent));
        }

        private void SaveScriptBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files|*.txt|All files|*.*";
                saveFileDialog.Title = "Save Script File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    try
                    {
                        File.WriteAllText(fileName, multiCommandTextBox.Text);
                        MessageBox.Show("Script saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void LoadScriptBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files|*.txt|All files|*.*";
                openFileDialog.Title = "Open Script File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    try
                    {
                        string scriptContent = File.ReadAllText(fileName);
                        multiCommandTextBox.Text = scriptContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void ExecuteScript(string scriptContent)
        {
            string[] lines = scriptContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var variables = new Dictionary<string, int>();
            int currentLine = 0;

            while (currentLine < lines.Length)
            {
                string line = lines[currentLine].Trim();

                if (IsVariableAssignment(line))
                {
                    ProcessVariableAssignment(line, variables);
                    currentLine++;
                    continue;
                }

                if (line.Trim().StartsWith("while", StringComparison.OrdinalIgnoreCase))
                {
                    currentLine = ExecuteWhileLoop(lines, currentLine, variables);
                    continue;
                }

                if (line.StartsWith("If"))
                {
                    currentLine = ExecuteIfStatement(lines, currentLine, variables);
                    continue;
                }

                if (line.Trim().Equals("endif", StringComparison.OrdinalIgnoreCase))
                {
                    // Do nothing; Endif is handled within ExecuteIfStatement
                    currentLine++;
                    continue;
                }

                // Check if the line represents a recognized command by GraphicsCommands
                if (IsRecognizedGraphicsCommand(line))
                {
                    // Substitute variable values into the command
                    line = SubstituteVariableValues(line, variables);

                    // Invoke the command on the canvas using GraphicsCommands
                    canvas.Invoke((MethodInvoker)delegate
                    {
                        CommandParser parser = new CommandParser(line);
                        canvas.GraphicsCommands.ExecuteDrawing(parser);
                    });
                }
                // Check if the line represents a recognized command by BasicCommands
                else if (IsRecognizedBasicCommand(line))
                {
                    // Substitute variable values into the command
                    line = SubstituteVariableValues(line, variables);

                    // Invoke the command on the canvas using BasicCommands
                    canvas.Invoke((MethodInvoker)delegate
                    {
                        CommandParser parser = new CommandParser(line);
                        canvas.BasicCommands.ExecuteDrawing(parser);
                    });
                }
                else
                {
                    MessageBox.Show("Unrecognized command: " + line, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                currentLine++;
            }
        }

        private bool IsRecognizedGraphicsCommand(string line)
        {
            string command = line.Split(' ')[0].ToLower();
            return canvas.GraphicsCommands.ContainsGraphicsCommand(command);
        }

        private bool IsRecognizedBasicCommand(string line)
        {
            string command = line.Split(' ')[0].ToLower();
            return canvas.BasicCommands.ContainsBasicCommand(command);
        }

        private bool IsVariableAssignment(string line)
        {
            return line.Contains("=");
        }

        private void ProcessVariableAssignment(string line, Dictionary<string, int> variables)
        {
            string[] parts = line.Split('=');
            if (parts.Length == 2)
            {
                string variableName = parts[0].Trim();
                string value = parts[1].Trim();

                if (value.EndsWith("++"))
                {
                    value = value.TrimEnd('+');
                    if (variables.TryGetValue(value, out int previousValue))
                    {
                        variables[variableName] = previousValue + 1;
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show($"Variable '{value}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
                else if (value.Contains("+") || value.Contains("-") || value.Contains("*") || value.Contains("/"))
                {
                    // Perform arithmetic operation
                    int result = EvaluateArithmeticOperation(value, variables);
                    if (result != int.MinValue)
                    {
                        variables[variableName] = result;
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show($"Error evaluating arithmetic expression: {value}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
                else if (int.TryParse(value, out int numericValue))
                {
                    variables[variableName] = numericValue;
                }
                else if (variables.TryGetValue(value, out int variableValue))
                {
                    variables[variableName] = variableValue;
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Invalid assignment: {line}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Invalid assignment: {line}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
        }

        private int ExecuteWhileLoop(string[] lines, int startLine, Dictionary<string, int> variables)
        {
            string condition = lines[startLine].Substring(6).Trim();
            int endLoopLine = FindEndLoopLine(lines, startLine);

            int currentLine = startLine + 1;
            while (EvaluateCondition(condition, variables))
            {
                while (currentLine < endLoopLine)
                {
                    string loopLine = lines[currentLine].Trim();

                    // Substitute variable values into the loop line
                    loopLine = SubstituteVariableValues(loopLine, variables);

                    // Check if the loop line represents a recognized command by GraphicsCommands
                    if (IsRecognizedGraphicsCommand(loopLine))
                    {
                        CommandParser parser = new CommandParser(loopLine);
                        canvas.GraphicsCommands.ExecuteDrawing(parser);
                    }
                    // Check if the loop line represents a recognized command by BasicCommands
                    else if (IsRecognizedBasicCommand(loopLine))
                    {
                        CommandParser parser = new CommandParser(loopLine);
                        canvas.BasicCommands.ExecuteDrawing(parser);
                    }
                    else if (IsVariableAssignment(loopLine))
                    {
                        ProcessVariableAssignment(loopLine, variables);
                    }
                    currentLine++;
                }

                // Reset currentLine to start of loop for next iteration
                currentLine = startLine + 1;

                // Update the condition with the latest variable values
                condition = lines[startLine].Substring(6).Trim();
                condition = SubstituteVariableValues(condition, variables);
            }

            return endLoopLine + 1; // Return the line number after "Endloop"
        }



        private int FindEndLoopLine(string[] lines, int startLine)
        {
            for (int i = startLine + 1; i < lines.Length; i++)
            {
                if (lines[i].Trim().Equals("endloop", StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            this.Invoke((MethodInvoker)delegate
            {

                MessageBox.Show("Endloop not found for the while loop starting at line " + startLine, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
            return -1; // Return an invalid line number
        }

        private int ExecuteIfStatement(string[] lines, int startLine, Dictionary<string, int> variables)
        {
            string condition = lines[startLine].Substring(2).Trim(); // Assuming "If " is 2 characters
            int endIfLine = FindEndIfLine(lines, startLine);

            if (EvaluateCondition(condition, variables))
            {
                int currentLine = startLine + 1;
                while (currentLine < endIfLine)
                {
                    string ifLine = lines[currentLine].Trim();

                    // Substitute variable values into the if line
                    ifLine = SubstituteVariableValues(ifLine, variables);

                    // Check if the if line represents a recognized command by GraphicsCommands
                    if (IsRecognizedGraphicsCommand(ifLine))
                    {
                        CommandParser parser = new CommandParser(ifLine);
                        canvas.GraphicsCommands.ExecuteDrawing(parser);
                    }
                    // Check if the if line represents a recognized command by BasicCommands
                    else if (IsRecognizedBasicCommand(ifLine))
                    {
                        CommandParser parser = new CommandParser(ifLine);
                        canvas.BasicCommands.ExecuteDrawing(parser);
                    }
                    else if (IsVariableAssignment(ifLine))
                    {
                        ProcessVariableAssignment(ifLine, variables);
                    }
                    currentLine++;
                }
            }

            return endIfLine + 1; // Return the line number after "Endif"
        }

        private int FindEndIfLine(string[] lines, int startLine)
        {
            for (int i = startLine + 1; i < lines.Length; i++)
            {
                if (lines[i].Trim().Equals("endif", StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("Endif not found for the if statement starting at line " + startLine, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
            return -1; 
        }

        private bool EvaluateCondition(string condition, Dictionary<string, int> variables)
        {
            string[] parts = condition.Split(new[] { '<', '>', '=', '=' }, 2);
            if (parts.Length == 2)
            {
                string variableName = parts[0].Trim();
                string valuePart = parts[1].Trim();

                if (variables.TryGetValue(variableName, out int variableValue))
                {
                    if (int.TryParse(valuePart, out int conditionValue))
                    {
                        if (condition.Contains("<"))
                        {
                            return variableValue < conditionValue;
                        }
                        else if (condition.Contains(">"))
                        {
                            return variableValue > conditionValue;
                        }
                        else if (condition.Contains("="))
                        {
                            return variableValue == conditionValue;
                        }
                        else if (condition.Contains("!="))
                        {
                            return variableValue != conditionValue;
                        }
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show($"Invalid number format in condition: {valuePart}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {

                        MessageBox.Show($"Variable '{variableName}' is not defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Invalid condition format: {condition}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
            return false;
        }


        private string SubstituteVariableValues(string line, Dictionary<string, int> variables)
        {
            // Split the line into tokens
            string[] tokens = line.Split(' ');

            // Iterate through tokens to check for variables
            for (int i = 1; i < tokens.Length; i++) // Start from index 1 to skip the command
            {
                if (variables.ContainsKey(tokens[i])) // Check if the token is a variable
                {
                    // Replace the variable with its value
                    tokens[i] = variables[tokens[i]].ToString();
                }
            }

            // Reconstruct the line with substituted variable values
            return string.Join(" ", tokens);
        }


        private int EvaluateArithmeticOperation(string expression, Dictionary<string, int> variables)
        {
            try
            {
                DataTable dt = new DataTable();
                var result = dt.Compute(expression, "");
                return Convert.ToInt32(result);
            }
            catch (Exception)
            {
                return int.MinValue;
            }
        }

        private void multiCommandTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.Location;

            this.Text = $"Mouse Position: {mousePosition.X}, {mousePosition.Y}";
        }
    }
}
