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

    }
}