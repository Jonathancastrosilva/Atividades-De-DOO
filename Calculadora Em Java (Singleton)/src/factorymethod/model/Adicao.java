package factorymethod.model;

public class Adicao implements Operador  {

    private static Adicao instance;

    private Adicao() {}

    public static Adicao getInstance() {
        if (instance == null) {
            instance = new Adicao();
        }

        return instance;
    }

    @Override
    public Operador clone() {
        return new Adicao();
    }

    @Override
    public double calcular(double a, double b) {
        System.out.println(a + " + " + b + " = " + (a + b));
        return a + b;
    }
}