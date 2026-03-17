using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment09_Gamma
{
    
  internal class Condiment
  {
      private string condimentName;
      private int condimentCalories;

      public Condiment(string condimentName, int condimentCalories)
      {
          this.condimentName = condimentName;
          this.condimentCalories = condimentCalories;
      }

      public string getName()
      {
          return this.condimentName;
      }
      public int getCalories()
      {
          return this.condimentCalories;
      }

      public void setName(string condimentName)
      {
          this.condimentName = condimentName;
      }
      public void setCalories(int condimentCalories)
      {
          this.condimentCalories = condimentCalories;
      }

      public override string ToString()
      {
          return this.condimentName;
      }
  }



}
