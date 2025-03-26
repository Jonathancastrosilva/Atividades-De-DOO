package factorymethod.model;

public class Adicao implements Operador  {

    @Override
    public Operador clone() {
        return new Adicao();
    }

    @Override
    public double calcular(double a, double b) {
        System.out.print(a + " + " + b + " = ");
        return a + b;
    }
}