package org.example.model;

import java.io.Serializable;

public abstract class Entity<ID> implements Serializable {

    private ID id;
    public ID getId() {
        return id;
    }
    public void setId(ID id) {
        this.id = id;
    }

    @Override
    public abstract String toString();
}