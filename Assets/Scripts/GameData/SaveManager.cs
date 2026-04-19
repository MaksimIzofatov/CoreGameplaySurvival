namespace GameData
{
    public class SaveManager
    {
        public GameSaveData GameSaveData { get; private set; }
        
        public void Save()
        {
            
        }

        public GlobalResourceData GetGlobalResourceData()
        {
            return GameSaveData.GlobalResourceData;
        }

        public BuildingData GetBuildingData(int typeResource)
        {
            return null;
        }
    }
}