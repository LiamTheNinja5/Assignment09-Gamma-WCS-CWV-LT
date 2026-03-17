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

      public string GetCondimentName()
      {
          return this.condimentName;
      }
      public int GetCondimentCalories()
      {
          return this.condimentCalories;
      }

      public void SetCondimentName(string condimentName)
      {
          this.condimentName = condimentName;
      }
      public void SetCondimentCalories(int condimentCalories)
      {
          this.condimentCalories = condimentCalories;
      }

      public override string ToString()
      {
          return this.condimentName;
      }
  }



}
