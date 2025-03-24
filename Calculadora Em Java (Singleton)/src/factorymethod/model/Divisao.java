package factorymethod.model;

public final class Divisao implements Operador  {

    private static Divisao instance;

    // Construtor privado para evitar instâncias externas
    private Divisao() {}

    public static Divisao getInstance() {
        if (instance == null) {
            instance = new Divisao();
        }
        return instance;
    }

    @Override
    public void calcular(double a, double b) {
        if (b == 0) {
            System.out.println("Dividir por 0... IMPOSSIVEL");
        }
        else{
            System.out.println(a + " / " + b + " = " + (a / b));
        }
    }
}