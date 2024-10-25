public class ClassDataGridViewClearer
{
    private DataGridView dataGridView;

    // コンストラクタ名をクラス名に合わせる
    public ClassDataGridViewClearer(DataGridView dgv)
    {
        this.dataGridView = dgv;
    }

    // データグリッドビューをクリアするメソッド 
    public void Clear()
    {
        dataGridView.DataSource = null; // データソースをクリア 
        dataGridView.Rows.Clear(); // 行をクリア 
        dataGridView.Refresh(); // 表示を更新 
    }
}
