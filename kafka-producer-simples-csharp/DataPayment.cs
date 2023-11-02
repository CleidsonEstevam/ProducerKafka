using System.Security.Cryptography;
using System.Text;
using System;

public class DataPayment
{
    public string Name { get; set; }
    public string CPF { get; set; } 
    public int Age { get; set; }

    public DataPayment()
    {
        Name = "Mayara Cristina Silva Barros";
        CPF = "10346000000";
        Age = 28;
    }
}
