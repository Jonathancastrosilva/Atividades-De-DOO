package factorymethod.factory;

import factorymethod.model.Operador;
import java.lang.reflect.InvocationTargetException;

public class Factory {

    private static Factory instance;

    private Factory() {}

    public static Factory getInstance() {
        if (instance == null) {
            instance = new Factory();
        }
        return instance;
    }

    public static Operador factory(String tipo){
        
        try {
            Object classeInstanciada = Class.forName("factorymethod.model."+tipo).getDeclaredConstructor().newInstance();
            return (Operador)classeInstanciada;
        } catch (IllegalAccessException | NoSuchMethodException | ClassNotFoundException | InvocationTargetException | InstantiationException e) {
            System.out.println("Operação inválida!");
            //e.printStackTrace();
            return null;
        }         
    }
}
