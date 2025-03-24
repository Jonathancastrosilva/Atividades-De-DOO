package factorymethod.model;

public final class Adicao implements Operador  {

    private static Adicao instance;

    // Construtor privado para evitar instâncias externas
    private Adicao() {}

    public static Adicao getInstance() {
        if (instance == null) {
            instance = new Adicao();
        }
        return instance;
    }

    @Override
    public void calcular(double a, double b) {
        System.out.println(a + " + " + b + " = " + (a + b));
    }
}