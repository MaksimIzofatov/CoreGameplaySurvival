using System;

namespace Data
{
    [Serializable]
    public class Resource
    {
        public double Count { get;  set; }
        public TypeResource TypeResource {get; set;}

        public Resource(double count, TypeResource typeResource)
        {
            Count = count;
            TypeResource = typeResource;
        }

        public double AddCountResource(double currentResource)
        {
            Count += currentResource;
            return Count;
        }
        
        public double RemoveCountResource(double currentResource)
        {
            Count -= currentResource;
            return Count;
        }
    }
}