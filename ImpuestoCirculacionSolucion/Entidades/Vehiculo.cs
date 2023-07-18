

namespace Entidades
{
    public class Vehiculo
    {
        public Vehiculo(string marca, string modelo, int anioMatriculacion, double valorBase)
        {
            Marca = marca;
            Modelo = modelo;
            AnioMatriculacion = anioMatriculacion;
            ValorBase = valorBase;
        }
        public string Marca { get; set; }

        public string Modelo { get; set; }
        public int AnioMatriculacion { get; set; }
        public double ValorBase { get; set; }

        public enum Etiqueta
        {
            sinEtiqueta,
            B,
            C,
            ECO,
            CERO
        }

        private Etiqueta etiqueta;

        public void SetEtiqueta(Etiqueta etiqueta)
        {
            this.etiqueta = etiqueta;
        }

        private int aniosAntiguedad()
        {

            return DateTime.Now.Year - AnioMatriculacion;

        }

        public void CalcularImpuestoCirculacion()
        {
            int anios= aniosAntiguedad();

            double incrementoPorAntiguedad = anios*0.1;
            double valorBase = ValorBase;

            double impuestoPorAntiguedad = valorBase*incrementoPorAntiguedad;
            double impuestoPorEtiqueta = 0;
            double impuestoTotal = 0;

            switch (etiqueta)
            {
                case Etiqueta.sinEtiqueta:
                    impuestoPorEtiqueta=valorBase*0.25;
                    impuestoTotal = impuestoPorAntiguedad + impuestoPorEtiqueta;
                    break;
                case Etiqueta.B:
                    impuestoPorEtiqueta = valorBase * 0.15;
                    impuestoTotal = impuestoPorAntiguedad + impuestoPorEtiqueta;
                    break;
                case Etiqueta.C:
                    impuestoPorEtiqueta = valorBase * 0.10;
                    impuestoTotal = impuestoPorAntiguedad + impuestoPorEtiqueta;
                    break;
                case Etiqueta.ECO:
                    impuestoPorEtiqueta = valorBase * 0.05;
                    impuestoTotal = impuestoPorAntiguedad + impuestoPorEtiqueta;
                    break;
                case Etiqueta.CERO:
                    impuestoPorEtiqueta = 0;
                    impuestoTotal = impuestoPorAntiguedad + impuestoPorEtiqueta;
                    break;
            }

            Console.WriteLine($"{Marca} {Modelo} con etiqueta {etiqueta} tiene {anios} años de antiguedad y tiene un impuesto de {impuestoTotal}");
        }
        
    }
}
