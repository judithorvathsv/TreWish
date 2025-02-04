import React, { useContext, useState } from "react";
import { useNavigate } from "@tanstack/react-router";
import { saveNewWish } from "../utils/wishFetch";
import { WishContext } from "../context/wishContext";

const CreateWishForm = () => {
  const { refreshWishList } = useContext(WishContext);
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    name: "",
    description: "",
    price: "",
    webPageLink: "",
  });
  const [errors, setErrors] = useState({
    name: "",
    price: "",
  });

  const [submitError, setSubmitError] = useState("");

  const handleCancel = () => {
    navigate({ to: "/wishList" });
  };

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const validateForm = () => {
    let isValid = true;
    const newErrors = { name: "", price: "" };

    if (!formData.name.trim()) {
      newErrors.name = "Name is required";
      isValid = false;
    }

    if (!formData.price || isNaN(Number(formData.price))) {
      newErrors.price = "Price must be a valid number";
      isValid = false;
    }

    setErrors(newErrors);
    return isValid;
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (validateForm()) {
      try {
        saveNewWish(
          formData.name,
          formData.description,
          formData.price,
          formData.webPageLink
        );
        alert("Wish added successfully!");
        refreshWishList();
        navigate({ to: "/wishList" });
      } catch (error) {
        console.error("Error saving wish:", error);
        setSubmitError("Failed to create wish. Please try again.");
      }
    }
  };

  if (submitError)
    return (
      <div>
        Error loading users:
        {typeof submitError === "string" ? submitError : "An error occurred"}
      </div>
    );

  return (
    <div>
      <h2>Create New Wish</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="name">Name:</label>
          <input
            type="text"
            id="name"
            name="name"
            value={formData.name}
            onChange={handleChange}
            required
          />
          {errors.name && <span className="error">{errors.name}</span>}
        </div>
        <div>
          <label htmlFor="description">Description (optional):</label>
          <textarea
            id="description"
            name="description"
            value={formData.description}
            onChange={handleChange}
          />
        </div>
        <div>
          <label htmlFor="price">Price:</label>
          <input
            type="number"
            id="price"
            name="price"
            value={formData.price}
            onChange={handleChange}
            step="0.01"
            required
          />
          {errors.price && <span className="error">{errors.price}</span>}
        </div>
        <div>
          <label htmlFor="webPageLink">Web Page Link (optional):</label>
          <input
            type="url"
            id="webPageLink"
            name="webPageLink"
            value={formData.webPageLink}
            onChange={handleChange}
          />
        </div>
        <button type="submit">Save</button>
        <button type="button" onClick={handleCancel}>
          Cancel
        </button>
      </form>
    </div>
  );
};

export default CreateWishForm;
