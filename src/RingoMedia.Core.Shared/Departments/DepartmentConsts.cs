namespace RingoMedia.Departments
{
    public class DepartmentConsts
    {

        public const int MaxNameLength = 128;



        public const int MaxDepth = 16;


        public const int CodeUnitLength = 5;




        public const int MaxDescriptionLength = 255;



        public const int MaxCodeLength = MaxDepth * (CodeUnitLength + 1) - 1;

    }
}