class RoomsController < ApplicationController
    def create
        puts params[:name]
        puts params[:age]
        @room = Room.new(name: params[:name], password: params[:password], floor_image_url: params[:floor_image_url])
        @room.save
    end

    def show
        puts params[:name]
        puts params[:password]
        roomdata = Room.find_by(name: params[:name], password: params[:password]);
        render json: roomdata
        # render json: roomdata['password'], roomdata['floor_image_url']
    end
end
