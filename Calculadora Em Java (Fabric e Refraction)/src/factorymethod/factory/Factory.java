package factorymethod.factory;

import java.lang.reflect.InvocationTargetException;

import factorymethod.model.Operador;
public class Factory {
    
    public static Operador factory(String tipo){
        
        try {
            Object classeInstanciada = Class.forName("factorymethod.model."+tipo).getDeclaredConstructor().newInstance();
            return (Operador) classeInstanciada;
        } catch (InstantiationException | IllegalAccessException | ClassNotFoundException | NoSuchMethodException | InvocationTargetException e) {
            System.out.println("Operação inválida!");
            return null;
        }         
    }
}
