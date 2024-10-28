type ProductType = {
  id: string;
  name: string;
  price: number;
};

export type ProductItemType = {
  product: ProductType;
  quantity: number;
};
