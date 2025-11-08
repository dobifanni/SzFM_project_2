public class FloorCounterSystem : Singleton<FloorCounterSystem>
{
    public static int FloorCount;

    public static void FloorNumberUp()
    {
        FloorCount++;
    }
}