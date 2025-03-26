package factorymethod.model;

public class Subtracao implements Operador  {

    @Override
    public Operador clone() {
        return new Subtracao();
    }

    @Override
    public double calcular(double a, double b) {
        System.out.print(a + " - " + b + " = ");
        return a - b;
    }
}