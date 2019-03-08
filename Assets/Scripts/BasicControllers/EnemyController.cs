
public abstract class EnemyController : BaseController
{
    public int hp;

    public virtual void DamagedAction(int loss)
    {
        hp -= loss;

        if (hp <= 0)
            Destroy(gameObject);
    }
}
