try {

    string  userInput = textBox1.text;

    int result =  100 / int.Parse(userInput);
    Console.WriteLine($"The result is {result}");
}

catch (FormatException ex){
    Console.WriteLine($"Please enter correct numerical value { ex.Message}");
}

catch(DivideByZeroException ex ){
    Console.WriteLine($"Cannot divide a number by zero {ex.Message}")''
}

catch(Exception ex){
    Console.WriteLine("An exception occurred ", ex.Message);
}

finally ({
    
}