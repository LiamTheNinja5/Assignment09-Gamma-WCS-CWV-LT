using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment09_Gamma
{
    internal class Sandwich
    {
        public class sandwich
        {
            private Bread bread;
            private SandwichFilling filling;
            private List<Condiment> condiments;


            public sandwich(Bread bread, SandwichFilling filling, List<Condiment> condiments)
            {
                this.bread = bread;
                this.filling = filling;
                this.condiments = condiments;
            }

            public Bread GetBread()
            {
                return this.bread;
            }
            public SandwichFilling GetFilling()
            {
                return this.filling;
            }
            public List<Condiment> GetCondiments()
            {
                return this.condiments;
            }

        }

    }
}
