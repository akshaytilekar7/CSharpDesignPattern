namespace POC.Business.Service
{
    public class HelperSer
    {
        public bool IsEven(int no)
        {
            if (no % 2 == 0)
                return true;
            return false;
        }
    }
}
