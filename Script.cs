voidMain()
{
    var block = new List<IMyTerminalBlock>();
    GridTerminalSystem.GetBlocksOfType<IMyRadioAntenna>(block);
    var antenna = block[0];

    double max = 0.0;
    double curr = 0.0;

    var blocks = new List<IMyTerminalBlock>();
    GridTerminalSystem.GetBlocksOfType<IMyCargoContainer>(blocks);

    for(int i=0; i < blocks.Count ; i++)
    {
        var container = blocks[i];

        var inventoryOwner = (IMyInventoryOwner)container;
        var sourceInventory = inventoryOwner.GetInventory(0);
        max += (double)sourceInventory.MaxVolume;
        curr += (double)sourceInventory.CurrentVolume;
    }

    var fill = (double)curr/(double)max;
    int percent = (int)(fill*100);

    if(percent > 0)
    {
        antenna.SetCustomName("Cargo " + percent.ToString() + " percent full");
    }
    else
    {
        antenna.SetCustomName("Container is empty");
    }
}
