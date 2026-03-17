using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment09_Gamma
{
     
    internal class SandwichFilling
{
    private string fillingName;
    private int fillingCalories;

    public SandwichFilling(string fillingName, int fillingCalories)
    {
        this.fillingName = fillingName;
        this.fillingCalories = fillingCalories;
    }

    public string GetFillingName()
    {
        return this.fillingName;
    }
    public int GetFillingCalories()
    {
        return this.fillingCalories;
    }

    public void SetFillingName(string fillingName)
    {
        this.fillingName = fillingName;
    }
    public void SetFillingCalories(int fillingCalories)
    {
        this.fillingCalories = fillingCalories;
    }

    public override string ToString()
    {
        return this.fillingName;
    }
}

}

