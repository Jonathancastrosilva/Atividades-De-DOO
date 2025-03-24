package factorymethod.model;

public final class Subtracao implements Operador  {

    private static Subtracao instance;

    // Construtor privado para evitar instâncias externas
    private Subtracao() {}

    public static Subtracao getInstance() {
        if (instance == null) {
            instance = new Subtracao();
        }
        return instance;
    }

    @Override
    public void calcular(double a, double b) {
        System.out.println(a + " - " + b + " = " + (a - b));
    }
}