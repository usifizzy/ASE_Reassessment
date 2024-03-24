## Introduction

The ASE application is a versatile programming environment that allows users to execute both basic and graphic commands to create shapes on a canvas within the application's interface. This README serves as a guide to understanding the application's functionality, structure, and usage.

## Features

- Execute single-line or multi-line commands.
- Support for both basic and graphic commands.
- Drawing shapes such as circles, rectangles, triangles, and concentric circles.
- Clearing the canvas, changing colors, filling shapes, and resetting configurations.
- Error handling for unrecognized commands.

## Getting Started

### Prerequisites

- Windows operating system.
- Microsoft .NET Framework.

### Installation

1. Clone the repository from [GitHub](https://github.com/usifizzy/ASE_Reassessment).
2. Open the solution file (`ASE.sln`) in Visual Studio.
3. Build the solution to ensure all dependencies are resolved.

### Usage

1. Launch the ASE application.
2. Enter commands in the provided command input area.
3. Press Enter or click on the Execute button to execute the command.
4. View the drawn shapes on the canvas area.
5. Explore different commands to create various shapes and manipulate the canvas.

## Application Structure

The ASE application consists of the following key components:

1. **Canvas**: Represents the drawing area where shapes are rendered.
2. **CommandParser**: Parses user input into command and argument.
3. **BasicCommands**: Handles basic commands such as clearing the screen, changing colors, etc.
4. **GraphicsCommands**: Handles graphic commands such as drawing circles, rectangles, etc.
5. **Shapes**: Contains classes for different shape commands (e.g., CircleCommand, RectangleCommand).

## Classes Overview

### BasicCommands

- **Constructor**: Initializes the canvas object.
- **ContainsBasicCommand**: Checks if a basic command is present in the dictionary.
- **ExecuteDrawing**: Executes drawing based on the parsed command.

### GraphicsCommands

- **Constructor**: Initializes the canvas object.
- **ContainsGraphicsCommand**: Checks if a graphic command is present in the dictionary.
- **ExecuteDrawing**: Executes drawing based on the parsed command.

## Example Commands

- **Basic Commands**:
  - `clear`: Clears the canvas.
  - `color`: Changes the color of the pen.
  - `fill`: Fills the interior of a shape.
  - `reset`: Resets configurations to default.
  - `point`: Moves the pen to a specified point.
  - `drawto`: Draws a line from the current point to the specified point.

- **Graphic Commands**:
  - `circle`: Draws a circle. Example: `circle 120` (where 120 is the radius).
  - `rectangle`: Draws a rectangle.
  - `triangle`: Draws a triangle.
  - `concircle`: Draws concentric circles.

## Testing Commands

To test a command, follow these steps:

- **Drawing a Circle**: Use the `circle` command followed by the radius. For example, to draw a circle with a radius of 120 pixels, use the command: `circle 120`.

- **Drawing a Rectangle**: Use the `rectangle` command followed by the width and height. For example, to draw a rectangle with a width of 50 pixels and a height of 70 pixels, use the command: `rectangle 50 70`.

- **Drawing a Triangle**: Use the `triangle` command followed by the height or length of sides. For example, to draw a triangle with a height of 100 pixels, use the command: `triangle 100`.

- **Drawing a Concentric Circle**: Use the `concentriccircle` command followed by the radius and the number of circles. For example, to draw concentric circles with a radius of 50 pixels and 5 circles, use the command: `concircle 50 5`.

- **Changing Color**: Use the `color` command followed by the new color name. For example, to change the color to red, use the command: `color red`.

- **Filling Shapes**: Use the `fill` command followed by `on` or `off` to enable or disable filling. For example, to turn on filling, use the command: `fill on`.

- **Clearing the Canvas**: Use the `clear` command to clear the canvas. Alternatively, you can click the Clear button on the interface.

- **Resetting Configurations**: Use the `reset` command to reset all settings to default.

- **Moving the Pen**: Use the `point` command followed by the coordinates of the new point. For example, to move the pen to coordinates (100, 70), use the command: `point 100 70`.

- **Drawing to a Point**: Use the `drawto` command followed by the coordinates of the destination point. For example, to draw a line to coordinates (200, 150) from the current position, use the command: `drawto 200 150`.

Replace the arguments with appropriate values based on the command's requirements.


## Multiline Script

To execute multiline commands, follow these steps:

1. Enter multiline commands directly into the multiline input area or load an existing script.
2. Click the Run Script button to execute the multiline commands.

### Sample Script

# Multiline Script Demo

# Set initial parameters
radius = 50
width = 100
height = 100
count = 1

# Draw shapes in a loop
while count < 5
    # Draw a circle
    color blue
    circle radius
    
    # Draw a rectangle
    color red
    rectangle width height
    
    # Draw a triangle
    color green
    triangle height
    
    # Draw a concentric circle
    color cyan
    concircle radius 3
    
    # Move to a new position
    point 200 200
    
    # Increase parameters for next iteration
    radius = radius + 20
    width = width + 50
    height = height + 30
    
    # Increase count
    count = count + 1
endloop

# Fill shapes with alternating colors
fill on
count = 1
while count < 5
    # Draw a filled circle
    color yellow
    circle radius
    
    # Draw a filled rectangle
    color orange
    rectangle width height
    
    # Draw a filled triangle
    color purple
    triangle height
    
    # Draw concentric filled circles
    color pink
    concircle radius 3
    
    # Move to a new position
    drawto 400 400
    
    # Increase parameters for next iteration
    radius = radius + 20
    width = width + 50
    height = height + 30
    
    # Increase count
    count = count + 1
endloop

# Reset parameters and configurations
reset

## Contributing

Contributions to the Windform application are welcome! If you have suggestions for new features, improvements, or bug fixes, please submit a pull request.

## References

### Libraries and Tools Used

- **[YourProjectName](https://github.com/your/repository)**: Brief description of the project and how it was used in Windform.

- **[ChatGPT](https://openai.com/gpt)**: The language model used to generate conversational responses and assist with various tasks within the Windform application.

