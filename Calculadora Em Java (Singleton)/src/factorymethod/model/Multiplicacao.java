package factorymethod.model;

public class Multiplicacao implements Operador  {

    private static Multiplicacao instance;

    private Multiplicacao() {}

    public static Multiplicacao getInstance() {
        if (instance == null) {
            instance = new Multiplicacao();
        }

        return instance;
    }

    @Override
    public Operador clone() {
        return new Multiplicacao();
    }

    @Override
    public double calcular(double a, double b) {
        System.out.println(a + " * " + b + " = " + (a * b));
        return a * b;
    }
}