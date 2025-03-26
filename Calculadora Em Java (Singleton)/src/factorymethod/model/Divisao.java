package factorymethod.model;

public class Divisao implements Operador  {

    @Override
    public Operador clone() {
        return new Divisao();
    }

    @Override
    public double calcular(double a, double b) {
        if (b == 0) {
            throw new ArithmeticException("Divisão por zero não é permitida.");
        }
        System.out.print(a + " / " + b + " = ");
        return a / b;
    }
}