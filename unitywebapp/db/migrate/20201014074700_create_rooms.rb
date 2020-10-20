class CreateRooms < ActiveRecord::Migration[6.0]
  def change
    create_table :rooms do |t|
      t.string :name
      t.string :password
      t.text   :floor_image_url

      t.timestamps
    end
  end
end
