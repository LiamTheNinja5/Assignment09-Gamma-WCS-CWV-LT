using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment09_Gamma
{
    internal class Sandwich
    {
        public Sandwich()
        {
        }
        private Bread bread;
        private SandwichFilling filling;
        private List<Condiment> condiments;


        public Sandwich(Bread bread, SandwichFilling filling, List<Condiment> condiments)
        {
            this.bread = bread;
            this.filling = filling;
            this.condiments = condiments;
        }

        public Bread getBread()
        {
            return this.bread;
        }
        public SandwichFilling getFilling()
        {
            return this.filling;
        }
        public List<Condiment> getCondiments()
        {
            return this.condiments;
        }
    }
}
