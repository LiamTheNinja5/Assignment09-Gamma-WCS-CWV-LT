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

    public string getName()
    {
        return this.fillingName;
    }
    public int getCalories()
    {
        return this.fillingCalories;
    }

    public void setName(string fillingName)
    {
        this.fillingName = fillingName;
    }
    public void setCalories(int fillingCalories)
    {
        this.fillingCalories = fillingCalories;
    }

    public override string ToString()
    {
        return this.fillingName;
    }
}

}

