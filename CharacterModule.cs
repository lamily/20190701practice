using UnityEngine;

public static class CharacterModule {
    public static void CreateHero(string _name, Vector3 _position, Vector3 _rotation) {
        GameObject hero = Resources.Load(_name) as GameObject;
        Quaternion rotation = Quaternion.Euler(_rotation);
        UnityEngine.Object o = UnityEngine.Object.Instantiate(hero,_position,rotation) as GameObject;
        Debug.Log("英雄出来啦" + _name);
    }

    public static void CreateEnemy(Vector3 _position, Vector3 _rotation,int name)
    { 
        GameObject enemy = Resources.Load("Enemy") as GameObject;
        Quaternion rotation = Quaternion.Euler(_rotation);
       // enemy.tag = "Enemy";
        UnityEngine.Object o = UnityEngine.Object.Instantiate(enemy, _position, rotation) as GameObject;
        if (name==1)
        {
            o.name = "Boss";
        }
        else
        {
            o.name = "Enemy" + name;
        }
        Debug.Log("创建了怪物" + o.name);
    }
}