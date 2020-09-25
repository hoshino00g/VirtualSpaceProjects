Rails.application.routes.draw do
  resources :users #一括定義しているここで
  post '/', to: 'users#create_uni'
  get '/show_uni/:id', to:'users#show_uni'
  root to:'users#index'
  # match '*all', to: 'game#index', via: [:get]
  # root 'game#index'
  # For details on the DSL available within this file, see https://guides.rubyonrails.org/routing.html

end
