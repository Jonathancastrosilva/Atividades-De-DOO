package factorymethod.model;

public class Subtracao implements Operador  {
    @Override
    public void calcular(double a, double b) {
        System.out.println(a + " - " + b + " = " + (a - b));
    }
}
