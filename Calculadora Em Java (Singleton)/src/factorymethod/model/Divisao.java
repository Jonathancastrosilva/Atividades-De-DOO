package factorymethod.model;

public class Divisao implements Operador  {

    @Override
    public Operador clone() {
        return new Divisao();
    }

    @Override
    public double calcular(double a, double b) {
        System.out.println(a + " / " + b + " = ");
        return a / b;
    }
}