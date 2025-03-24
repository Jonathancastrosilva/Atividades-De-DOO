package factorymethod.factory;

import java.lang.reflect.InvocationTargetException;

import factorymethod.model.Operador;
public final class Factory {

    private static Factory instance;
    public int valor;

    private Factory(int valor) {
        this.valor = valor;
    }

    public static Factory getInstance(int valor) {
        if (instance == null) {
            instance = new Factory(valor);
        }
        return instance;
    }

    public static Operador factory(String tipo){
        
        try {
            Object classeInstanciada = Class.forName("factorymethod.model."+tipo).getMethod("getInstance").invoke(null);
            return (Operador)classeInstanciada;
        } catch (IllegalAccessException | ClassNotFoundException | NoSuchMethodException | InvocationTargetException e) {
            System.out.println("Operação inválida!");
            e.printStackTrace();
            return null;
        }         
    }
}
