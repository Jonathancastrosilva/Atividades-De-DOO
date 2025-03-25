package factorymethod.model;

public interface Operador {

    Operador clone();
    double calcular(double a, double b);
}
