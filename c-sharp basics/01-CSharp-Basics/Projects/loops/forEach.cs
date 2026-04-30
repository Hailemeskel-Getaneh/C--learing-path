
int[] numbers = {1, 3, 4, 5, 6, 9, 2};
int sum = 0;
int? max = numbers?[0];

foreach (int num in numbers){
    sum += num;
    if(num > max)
    {
        max = num;
    }
     
}

Console.WriteLine("sum:" + sum);
Console.WriteLine("The largest number is " + max);