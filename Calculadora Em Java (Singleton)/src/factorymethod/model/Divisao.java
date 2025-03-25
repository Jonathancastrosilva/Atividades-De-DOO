package factorymethod.model;

public class Divisao implements Operador  {

    private static Divisao instance;

    private Divisao() {}

    public static Divisao getInstance() {
        if (instance == null) {
            instance = new Divisao();
        }

        return instance;
    }

    @Override
    public Operador clone() {
        return new Divisao();
    }

    @Override
    public double calcular(double a, double b) {
        if (b == 0) {
            throw new ArithmeticException("Divisão por zero não é permitida.");
        }
        System.out.println(a + " / " + b + " = " + (a / b));
        return a / b;
    }
}