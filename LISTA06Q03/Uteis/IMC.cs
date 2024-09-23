namespace LISTA06Q03.Uteis
{
    public class IMC
    {
        public static double CalcularIMC(double peso, double altura)
        {
            if (altura == 0) 
            {
                throw new ArgumentException("Altura não pode ser zero.");
            }

            return peso / (altura * altura); 
        }
    }
}
