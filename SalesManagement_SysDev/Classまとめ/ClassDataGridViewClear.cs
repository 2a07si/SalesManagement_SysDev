public class DataGridViewClearer
{
    private DataGridView dataGridView;

    public DataGridViewClearer(DataGridView dgv)
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
