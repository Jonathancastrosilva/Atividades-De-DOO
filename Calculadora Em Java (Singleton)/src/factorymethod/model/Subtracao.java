package factorymethod.model;

public class Subtracao implements Operador  {

    private static Subtracao instance;

    private Subtracao() {}

    public static Subtracao getInstance() {
        if (instance == null) {
            instance = new Subtracao();
        }

        return instance;
    }

    @Override
    public Operador clone() {
        return new Subtracao();
    }

    @Override
    public double calcular(double a, double b) {
        System.out.println(a + " - " + b + " = " + (a - b));
        return a - b;
    }
}