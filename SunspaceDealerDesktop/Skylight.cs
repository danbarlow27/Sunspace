using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Skylight
    {
        private string type;
        private float setback;
        private bool isOperator;

        public Skylight();

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public float Setback
        {
            get
            { 
                return setback; 
            }
            set 
            { 
                setback = value; 
            }
        }
        public bool Operator 
        { 
            get 
            { 
                return isOperator; 
            } 
            set 
            { 
                isOperator = value; 
            } 
        }
        


    }
}