using System;
using System.Diagnostics;
using System.Net.WebSockets;

int customerAge = 25;
int itemsInCart = 3;
int employeeId = 12847;

string customerName = "John Doe";
string emailAddress = "john.doe@email.com";

bool isCustomerActive = true;

decimal productPrice = 30.55m; // monetary value -> m
double height = 10.5d;

char grade = 'A';

System.Console.WriteLine(customerName.ToUpper());

// var automatically determines the data type based on the value
var inferredAge = 30;
var inferredStatus = true;

System.Console.WriteLine($"Price: ${productPrice:F2}");

/// <summary>
/// increases the number of items in the cart
/// </summary>
itemsInCart += +1;

