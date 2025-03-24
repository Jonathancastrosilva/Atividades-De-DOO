package factorymethod.model;

public final class Multiplicacao implements Operador  {

    private static Multiplicacao instance;

    // Construtor privado para evitar instâncias externas
    private Multiplicacao() {}

    public static Multiplicacao getInstance() {
        if (instance == null) {
            instance = new Multiplicacao();
        }
        return instance;
    }

    @Override
    public void calcular(double a, double b) {
        System.out.println(a + " * " + b + " = " + (a * b));
    }
}