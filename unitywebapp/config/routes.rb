Rails.application.routes.draw do
  resources :users #一括定義しているここで
  post '/users_uni', to: 'users#create_uni'
  get '/show_uni/:id', to:'users#show_uni'
  
  post '/rooms', to: 'rooms#create'
  get '/rooms/:name/:password', to:'rooms#show' 

  root to:'users#index'
  # match '*all', to: 'game#index', via: [:get]
  # root 'game#index'
  # For details on the DSL available within this file, see https://guides.rubyonrails.org/routing.html

end
