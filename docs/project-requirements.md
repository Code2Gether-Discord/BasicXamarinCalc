# Project Requirements

## Format Template

- **Given** a condition is present
- **When** an event occurs
- **Then** perform a measurable action

## Number Input Requirements

- **Given** first number in displayed text is 0
- **When** a number (0-9) is pressed
- **Then** set the displayed text to the number <br><br>
- **Given** first number in displayed text is not a 0
- **When** a number (0-9) is pressed
- **Then** append pressed digit to displayed text <br><br>
- **Given** no decimal point exists on current displayed text
- **When** the decimal button is pressed
- **Then** append decimal button to displayed text

## Operator Input Requirements

- **Given** 2 numbers (X and Y) has been entered, and a mathematical operator has been pressed between the two
- **When** the equal (=) a button is pressed
- **Then** update the displayed text with the evaluated expression and set that value to X. <br><br>
- **Given** a number (X) has been entered
- **When** a mathematical operator has been pressed
- **Then** store the operator as the current operation and end the input for the first number (X), then start the input for the second (Y), and the last number entered should remain until the next number is entered <br><br>
- **Given** a number other than default has been entered
- **When** the % operator has been pressed
- **Then** update the number (X) as the result of: X / 100 <br><br>
- **Given** 1 numbers (X) has been entered
- **When** the equal (=) a button is pressed
- **Then** do nothing <br><br>
- **Given** 1 numbers (X) has been entered and an operator has been pressed
- **When** the equal (=) a button is pressed
- **Then** evaluate the expression where Y is equal to X <br><br>
- **Given** 1 number (X) has been entered,"Divide" (/) operator has been pressed, and 0 has been entered for (Y).
- **When** the equal (=) button is pressed.
- **Then** set displayed text to "div by 0 err", and do not store the result in first number (X). Clear everything ("CE") when a new digit is pressed

## Deleting/Clearing Requirements

- **Given** the display is not currently "0"
- **When** the "C" (clear) button is pressed
- **Then** remove the last character in the displayed text <br><br>
- **Given** a mathematical operator has been pressed, or the display is not currently "0", or a previously input number has been stored
- **When** the "CE" (clear everything) button is pressed
- **Then** reset all user input (stored numbers, displayed text, and set operator) to default value
