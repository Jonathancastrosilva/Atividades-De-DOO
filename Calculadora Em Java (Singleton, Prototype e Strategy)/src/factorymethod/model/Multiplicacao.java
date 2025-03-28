package factorymethod.model;

public class Multiplicacao implements Operador  {

    @Override
    public Operador clone() {
        return new Multiplicacao();
    }

    @Override
    public double calcular(double a, double b) {
        System.out.print(a + " * " + b + " = ");
        return a * b;
    }
}